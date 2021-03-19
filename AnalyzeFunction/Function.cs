using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LambdaSharp;
using LambdaSharp.EventBridge;

namespace Acme.Bitcoin.PriceAnalyzer.AnalyzeFunction {

    public sealed class BitcoinPriceEvent {

        //--- Properties ---
        [JsonPropertyName("bpi")]
        public Dictionary<string, BitcoinPrice> BitcoinPriceIndex { get; set; }

    }

    public sealed class BitcoinPrice {

        //--- Properties ---
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("rate_float")]
        public double Rate { get; set; }
    }

    public sealed class Function : ALambdaEventFunction<BitcoinPriceEvent> {

        //--- Constructors ---
        public Function() : base(new LambdaSharp.Serialization.LambdaSystemTextJsonSerializer()) { }

        //--- Methods ---
        public override async Task InitializeAsync(LambdaConfig config) {

            // TO-DO: add function initialization and reading configuration settings
        }

        public override async Task ProcessEventAsync(BitcoinPriceEvent message) {

            // TO-DO: add business logic
            LogInfo($"Received: {LambdaSerializer.Serialize(message)}");
        }
    }
}
