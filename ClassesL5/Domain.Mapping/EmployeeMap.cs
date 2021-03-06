﻿using Domain.Persons;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class EmployeeMap : SubclassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(x => x.Department).Not.Nullable();
            Map(x => x.Role).Not.Nullable();
        }
    }
}