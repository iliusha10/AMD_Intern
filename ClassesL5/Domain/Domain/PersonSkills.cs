using System;

namespace Domain.Domain
{
    public class PersonSkills : Entity
    {
        public virtual Person Person { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Level { get; protected set; }

        //public PersonSkills( string name, int level)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //        throw new ArgumentException("name is required.");
        //    Name = name;
        //    Level = level;
        //}

        public PersonSkills(Person person, string name, int level)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is required.");
            Name = name;
            Level = level;
            Person = person;
        }

        [Obsolete]
        protected PersonSkills()
        {
        }


        //public virtual Dictionary<string, int> SkillsDictionary { get; protected set; }


        //public virtual void AddSkill(string skillName, int level)
        //{
        //    try
        //    {
        //        SkillsDictionary.Add(skillName, level);
        //    }
        //    catch (ArgumentException)
        //    {
        //        Console.WriteLine("An skill with the name {0} already exist", skillName, level);
        //        int value;
        //        SkillsDictionary.TryGetValue(skillName, out value);
        //        if (value < level)
        //        {
        //            SkillsDictionary[skillName] = level;
        //            Console.WriteLine("Updated skill level from {0} to {1}", value, level);
        //        }
        //        else Console.WriteLine("The skill is already updated", skillName, level);
        //    }
        //}


        //public virtual void ShowSkills()
        //{
        //    if (SkillsDictionary.Count < 1) Console.WriteLine("There is no Skills");
        //    else
        //        foreach (KeyValuePair<string, int> skill in this.SkillsDictionary)
        //        {
        //            Console.WriteLine("Key = {0}, Value = {1}", skill.Key, skill.Value);
        //        }
        //}
    }
}