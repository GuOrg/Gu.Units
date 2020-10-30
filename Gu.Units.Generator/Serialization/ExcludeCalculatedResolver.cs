namespace Gu.Units.Generator
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public sealed class ExcludeCalculatedResolver : DefaultContractResolver
    {
        public static readonly ExcludeCalculatedResolver Default = new ExcludeCalculatedResolver();

        private ExcludeCalculatedResolver()
        {
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = _ => ShouldSerialize(member);
            return property;
        }

        private static bool ShouldSerialize(MemberInfo memberInfo)
        {
            return memberInfo switch
            {
                PropertyInfo { SetMethod: { } } => true,
                PropertyInfo { GetMethod: { } getMethod } => Attribute.IsDefined(getMethod, typeof(CompilerGeneratedAttribute)),
                _ => false,
            };
        }
    }
}
