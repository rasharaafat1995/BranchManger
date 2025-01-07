namespace BranchManagement.API.Helpers
{
    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            TDestination destination = new TDestination();
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProp in sourceProperties)
            {
                var destinationProp = destinationProperties.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);
                if (destinationProp != null && destinationProp.CanWrite)
                {
                    var value = sourceProp.GetValue(source);
                    destinationProp.SetValue(destination, value);
                }
            }

            return destination;
        }
    }

}
