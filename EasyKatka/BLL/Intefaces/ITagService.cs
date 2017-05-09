using Domain.Entities;
using System.Collections.Generic;

namespace BLL.Intefaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTags();
    }
}
