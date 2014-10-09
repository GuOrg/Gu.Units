namespace GeneratorBox.Generator
{
    using System.Collections.Generic;

    public class Settings
    {
        static Settings()
        {
            Descriptors = new List<UnitValue>
                              {
                                  new UnitValue
                                      {
                                          ClassName = "Unit1",
                                          Namespace = "GeneratorBox.Units",
                                          Properties =
                                              new[]
                                                  {
                                                      new Property { Name ="Prop1", ReturnType = "int" }
                                                  }
                                      },
                                      new UnitValue
                                      {
                                          ClassName = "Unit2",
                                          Namespace = "GeneratorBox.Units",
                                          Properties =
                                              new[]
                                                  {
                                                      new Property { Name ="Prop1", ReturnType = "int" }
                                                  },
                                          Fields = 
                                              new[]
                                                  {
                                                      new Field { Name ="Field1", Readonly = "readonly ", ReturnType = "int" }
                                                  }
                                      }

                              };
        }
        public Settings()
        {

        }
        public static List<UnitValue> Descriptors { get; set; }
    }
}
