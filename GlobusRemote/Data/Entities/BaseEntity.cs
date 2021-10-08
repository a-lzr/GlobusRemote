using System.ComponentModel.DataAnnotations.Schema;

namespace GlobusRemote.Data.Entities
{
    public abstract class BaseEntity
    {
        abstract public object GetId();

        abstract public bool IsEqual(object Id);
    }
}