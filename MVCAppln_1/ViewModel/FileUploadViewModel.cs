using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppln_1.ViewModel
{
    public class FileUploadViewModel : BaseViewModel
    {
        public HttpPostedFileBase fileUpload { get; set; } // provide the access to the uploadedfile by client.
    }
}