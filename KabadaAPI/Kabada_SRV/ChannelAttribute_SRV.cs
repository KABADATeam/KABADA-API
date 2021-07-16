namespace Kabada {
    partial class ChannelAttribute
    {
        public void unpack(string archived)
        {
            var t = Newtonsoft.Json.JsonConvert.DeserializeObject<ChannelAttribute>(archived);
            channel_type_id = t.channel_type_id;
            channel_subtype_id = t.channel_subtype_id;
            subtype_type_id = t.subtype_type_id;
            location_type_id = t.location_type_id;
            product_id = t.product_id;
            distribution_channels_id = t.distribution_channels_id;                   
        }
    }
    }
