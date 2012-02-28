using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public delegate void ProcessOutput(string message);

    public delegate void ProcessError(string message, Exception ex);

    public class SqlGenerationEngine
    {
        private readonly StringBuilder _builder;
        private IEnumerable<IGenerator> _generators;
        private SqlEntityMap _currentMap;

        public SqlGenerationEngine()
        {
            _builder = new StringBuilder();

            _generators = new IGenerator[]
                              {
                                  new TableGenerator(),
                                  new CreateProcedureGenerator(),
                                  new ReadByKeyProcedureGenerator(),
                                  new UpdateProcedureGenerator(),
                                  new DeleteProcedureGenerator(),
                              };
        }

        public event ProcessOutput Output;
        public event ProcessError Error;

        private void OnOutput(string msg)
        {
            ProcessOutput handler = Output;
            if (handler != null) handler(msg);
        }

        private void OnError(string msg, Exception ex)
        {
            ProcessError handler = Error;
            if (handler != null) handler(msg, ex);
        }

        public void Generate(IEnumerable<Type> types)
        {
            if (types == null)
            {
                try
                {
                    throw new ArgumentNullException("types");
                }
                catch (Exception ex)
                {
                    OnError("Missing parameter.", ex);   
                    throw;
                }
            }

            SetCurrentSqlEntityMap(types);

            RunGenerators();

            Finish();
        }

        private void SetCurrentSqlEntityMap(IEnumerable<Type> types)
        {
            try
            {
                _currentMap = SqlEntityMap.Generate(types.ToArray());
            }
            catch (Exception ex)
            {
                OnError("Couldn't create SqlEntityMap.", ex);   
                throw;
            }
        }

        private void RunGenerators()
        {
            var isGenerationFailed = _currentMap.Entities.Select(GenerateForSqlEntityInfo).Any(b => !b);

            if (isGenerationFailed)
            {
                try
                {
                    throw new Exception("Generation failed because not all entities were generated succesfully.");
                }
                catch (Exception ex)
                {
                    OnError(string.Format("Generation failed. Output so far was: {0}{1}", Environment.NewLine, _builder), ex);

                    _builder.Clear();

                    throw;
                }
            }
        }

        private bool GenerateForSqlEntityInfo(SqlEntityInfo entityInfo)
        {
            return this._generators.Select(g => PerformGenerate(g, entityInfo)).All(succes=>succes);
        }

        private bool PerformGenerate(IGenerator generator, SqlEntityInfo sqlEntityInfo)
        {
            try
            {
                OnOutput(string.Format("Generator {0} running for entity: {1}", generator.GetType().Name, sqlEntityInfo.Name));

                generator.GenerateSql(sqlEntityInfo, _builder);

                _builder.AppendLine("");
                _builder.AppendLine("GO");

                return true;
            }
            catch (Exception ex)
            {
                OnError("Error in a generator during generation.", ex);
                return false;
            }
        }

        private void Finish()
        {
            OnOutput("Generating done.");

            OnOutput("Output is:");

            OnOutput(_builder.ToString());
        }
    }
}