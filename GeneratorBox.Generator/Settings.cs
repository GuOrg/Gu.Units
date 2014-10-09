namespace GeneratorBox.Generator
{
    using System.Collections.Generic;

    public class Settings
    {
        static Settings()
        {
            Descriptors = new List<UnitValueDescriptor>
                              {
                                  new UnitValueDescriptor
                                      {
                                          ClassName = "Unit1",
                                          Namespace = "GeneratorBox.Units",
                                          Properties =
                                              new[]
                                                  {
                                                      new Property
                                                          {
                                                              PropertyName ="Prop1",
                                                              ReturnType = "int"
                                                          }
                                                  }
                                      },
                                      new UnitValueDescriptor
                                      {
                                          ClassName = "Unit2",
                                          Namespace = "GeneratorBox.Units",
                                          Properties =
                                              new[]
                                                  {
                                                      new Property
                                                          {
                                                              PropertyName ="Prop1",
                                                              ReturnType = "int"
                                                          }
                                                  }
                                      }

                              };
        }
        public Settings()
        {

        }
        public static List<UnitValueDescriptor> Descriptors { get; set; }
    }
}
