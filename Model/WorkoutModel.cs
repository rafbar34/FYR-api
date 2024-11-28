using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Model
{
    [Table("workout")]
    class WorkoutModel : BaseModel
    {
    
        [Column("id")]
        public int Id { get; set; }
    
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("workout_info")]
        public object WorkoutInfo { get; set; }

        [Column("duration")]
        public DateTime Duration { get; set; }

    }
}
