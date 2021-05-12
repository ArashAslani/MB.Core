using System.Collections.Generic;
using System.Net.Sockets;
using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> Comments;

        public ListModel(ICommentApplication commentApplication)
        {
            this._commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.List();
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }
    }
}
