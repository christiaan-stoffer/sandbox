using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace Sit.Framework.Portal.Dynamic
{
    public static class Proxy
    {
        public static T New<T>()
        {
            var type = typeof (T);

            if (!type.IsInterface)
            {
                throw new NotSupportedException(
                    "Type is not an interface. Generation of proxies for non-interfaces is not supported!");
            }

            var unit = new CodeCompileUnit();

            string nsName = "Sit.Proxy.Generated";
            var ns = new CodeNamespace(nsName);

            unit.ReferencedAssemblies.Add(type.Assembly.Location);
            unit.Namespaces.Add(ns);

            ns.Imports.Add(new CodeNamespaceImport(type.Namespace));

            string typeName = type.Name + "_Proxy";

            var codeTypeDeclaration = new CodeTypeDeclaration(typeName);
            codeTypeDeclaration.IsClass = true;

            codeTypeDeclaration.BaseTypes.Add(type);

            foreach(var prop in type.GetProperties())
            {
                string fieldName = "_" + prop.Name.ToLower();
                var fieldProp = new CodeMemberField(prop.PropertyType, fieldName);

                codeTypeDeclaration.Members.Add(fieldProp);

                var codeProp = new CodeMemberProperty();

                codeProp.Attributes = MemberAttributes.Public;
                codeProp.Type = new CodeTypeReference(prop.PropertyType);
                codeProp.Name = prop.Name;
                codeProp.HasGet = true;
                codeProp.HasSet = true;
                codeProp.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
                codeProp.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));

                codeTypeDeclaration.Members.Add(codeProp);
            }

            ns.Types.Add(codeTypeDeclaration);

            var provider = new CSharpCodeProvider();
            var compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            var result = provider.CompileAssemblyFromDom(compilerParams, unit);

            var pt = result.CompiledAssembly.GetType(nsName + "." + typeName);

            return (T)Activator.CreateInstance(pt);
        }
    }
}
