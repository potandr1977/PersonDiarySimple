﻿using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class GetPersonsRequestDto : Request
    {
        public int PageNo { get; set; }
        
        public int PageSize { get; set; }
    }
}
