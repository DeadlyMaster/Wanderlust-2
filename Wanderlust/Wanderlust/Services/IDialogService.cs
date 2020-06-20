using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Services
{
    public interface IDialogService
    {
        Task Showdialog(string message, string title, string buttonLabel);
    }
}
