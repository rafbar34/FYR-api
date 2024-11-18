using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Model
{
    [Table("users_exercises")]
    class ExercisesModel : BaseModel
    {

        [PrimaryKey("exe_id")]
        public int Exeid { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("info")]
        public object Info { get; set; }

        [Column("sets")]
        public string Sets { get; set; }
    }
}
