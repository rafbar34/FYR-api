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
    public class ExercisesUserModel : BaseModel
    {

        [Column("exe_id")]
        public int ExeId { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("info")]
        public InfoItem[] Info { get; set; }

        [Column("sets")]
        public string Sets { get; set; }

    }
    [Table("exercises")]
    public class ExercisesModel:BaseModel
    {

    [PrimaryKey("exe_id")]
    public int ExeId { get; private set; }
        [Column("name")]
        public string Name { get; set; }

        [Column("info")]
        public InfoItem[] Info { get; set; }

        [Column("sets")]
        public int Sets { get; set; }

        [Column("break_duration")]
        public int BreakDuration { get; set; }
        }
    }
public class InfoItem
{
    public float Weight { get; set; }
    public int Rep { get; set; }
    public int Set { get; set; }
}