using System;
using System.Linq.Expressions;
using Domain;

namespace API.ViewModels
{
  /// <summary>
  /// Class CommentViewModel
  /// </summary>
  public static class CommentViewModel
  {
    /// <summary>
    /// Func
    /// </summary>
    public static readonly Func<Comment, object> Create = Projection.Compile();

    /// <summary>
    /// Expression
    /// </summary>
    public static Expression<Func<Comment, object>> Projection =>
        comment => new
        {
          comment.Id,
          comment.ParentId,
          comment.Content,
          comment.HtmlContent,
        };
  }
}
