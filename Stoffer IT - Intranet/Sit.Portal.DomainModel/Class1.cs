using System;
using Sit.Framework.Portal.Content;

namespace Sit.Portal.DomainModel
{
    public interface IArticle : IEntity<int>
    {
        string Title { get; set; }

        string Description { get; set; }

        string Body { get; set; }

        string OverviewImage { get; set; }

        DateTime PublishDate { get; set; }

        string Author { get; set; }

        IArticleCategory Category { get; set; }

        string[] Keywords { get; set; }
    }

    public interface IBlog : IArticle
    {
    }

    public interface INews : IArticle
    {   
    }

    public interface IArticleCategory : IEntity<int>
    {
        string Name { get; set; }
    }
}
