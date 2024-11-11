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
    }

    [Table("users_survey")]
    class UsersSurveyModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("answers")]
        public ParametersModel Answers { get; set; }
        [Column("isCompleted")]
        public bool IsCompleted { get; set; }

    }
}
