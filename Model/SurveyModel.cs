using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FYR_api.Model
{

    [Table("survey")]
    class SurveyModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("question")]
        public string Question { get; set; }

        [Column("answers")]
        public object? Answers { get; set; }

        [Column("alias")]
        public string Alias { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("placeholder")]
        public string Placeholder { get; set; }
        [Column("min")]
        public int? Min { get; set; }
        [Column("max")]
        public int? Max { get;set; }
    }

    [Table("users_survey")]
    class UsersSurveyModel : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("sex")]
        public int Sex { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("pal")]
        public float Pal { get; set; }
        [Column("average_sleep")]
        public int Sleep { get; set; }
        [Column("is_completed")]
        public bool IsCompleted { get; set; }

    }

    [Table("daily_survey")]
    class DailySurveyModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("hip")]
        public float Hip { get; set; }

        [Column("waist")]
        public float Waist { get; set; }
        [Column("height")]
        public int Height { get; set; }
        [Column("weight")]
        public float Weight { get; set; }
        [Column("awake")]
        public DateTime Awake { get; set; }
        [Column("last_meal")]
        public DateTime Last_meal { get; set; }

        [Column("sleep")]
        public int Sleep { get; set; }
        [Column("wellbeing")]
        public int Wellbeing { get; set; }
    }
}
