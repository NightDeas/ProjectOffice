using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models.DTO
{
    public class AttachmentModel
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public byte[] Photo { get; set; }
        public string? NamePhoto { get; set; }
        public float? SizeFile { get; set; }

        public static ProjectOffice.DataBase.Entities.Attachment ToDbModel(AttachmentModel model)
        {
            ProjectOffice.DataBase.Entities.Attachment attachment = new ProjectOffice.DataBase.Entities.Attachment()
            {
                Id = model.Id,
                Link = model.Link,
                Photo = model.Photo,
            };
            return attachment;
        }
    }
}
