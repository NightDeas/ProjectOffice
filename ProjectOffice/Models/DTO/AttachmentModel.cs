using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models.DTO
{
    internal class AttachmentModel
    {
        public string? Link { get; set; }
        public byte[] Photo { get; set; }
        public string? NamePhoto { get; set; }
        public float? SizeFile { get; set; }
    }
}
