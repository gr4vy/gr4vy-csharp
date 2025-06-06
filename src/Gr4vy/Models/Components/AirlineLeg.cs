//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gr4vy.Models.Components
{
    using Gr4vy.Utils;
    using Newtonsoft.Json;
    using System;
    
    public class AirlineLeg
    {

        /// <summary>
        /// Arrival airport code of leg. 3-letter ISO code according to IATA official directory.
        /// </summary>
        [JsonProperty("arrival_airport")]
        public string? ArrivalAirport { get; set; } = null;

        /// <summary>
        /// The date and time of travel in local time at the arrival airport.
        /// </summary>
        [JsonProperty("arrival_at")]
        public DateTime? ArrivalAt { get; set; } = null;

        /// <summary>
        /// Arrival city name.
        /// </summary>
        [JsonProperty("arrival_city")]
        public string? ArrivalCity { get; set; } = null;

        /// <summary>
        /// Arrival country code in ISO 3166 format.
        /// </summary>
        [JsonProperty("arrival_country")]
        public string? ArrivalCountry { get; set; } = null;

        /// <summary>
        /// 3 character airline code as set by IATA.
        /// </summary>
        [JsonProperty("carrier_code")]
        public string? CarrierCode { get; set; } = null;

        /// <summary>
        /// Name of the airline.
        /// </summary>
        [JsonProperty("carrier_name")]
        public string? CarrierName { get; set; } = null;

        /// <summary>
        /// Two-character IATA code of the airline.
        /// </summary>
        [JsonProperty("iata_designator")]
        public string? IataDesignator { get; set; } = null;

        /// <summary>
        /// Three-character ICAO code of the airline.
        /// </summary>
        [JsonProperty("icao_code")]
        public string? IcaoCode { get; set; } = null;

        /// <summary>
        /// Coupon number associated with the leg.
        /// </summary>
        [JsonProperty("coupon_number")]
        public string? CouponNumber { get; set; } = null;

        /// <summary>
        /// Departure airport code of leg. 3-letter ISO code according to IATA official directory.
        /// </summary>
        [JsonProperty("departure_airport")]
        public string? DepartureAirport { get; set; } = null;

        /// <summary>
        /// The date and time of travel in local time at the departure airport.
        /// </summary>
        [JsonProperty("departure_at")]
        public DateTime? DepartureAt { get; set; } = null;

        /// <summary>
        /// Departure city name.
        /// </summary>
        [JsonProperty("departure_city")]
        public string? DepartureCity { get; set; } = null;

        /// <summary>
        /// Departure airport code of leg. 3-letter ISO code according to IATA official directory.
        /// </summary>
        [JsonProperty("departure_country")]
        public string? DepartureCountry { get; set; } = null;

        /// <summary>
        /// Departure tax amount charged by a country when a person is leaving the country.
        /// </summary>
        [JsonProperty("departure_tax_amount")]
        public long? DepartureTaxAmount { get; set; } = null;

        /// <summary>
        /// Amount of the ticket, for current leg of the trip, excluding taxes and fees.
        /// </summary>
        [JsonProperty("fare_amount")]
        public long? FareAmount { get; set; } = null;

        /// <summary>
        /// The alphanumeric code for the booking class of a ticket.
        /// </summary>
        [JsonProperty("fare_basis_code")]
        public string? FareBasisCode { get; set; } = null;

        /// <summary>
        /// Fee amount for current leg of the trip.
        /// </summary>
        [JsonProperty("fee_amount")]
        public long? FeeAmount { get; set; } = null;

        /// <summary>
        /// Indicates service class (first class, business class, etc.).
        /// </summary>
        [JsonProperty("flight_class")]
        public string? FlightClass { get; set; } = null;

        /// <summary>
        /// Unique identifier of the flight number.
        /// </summary>
        [JsonProperty("flight_number")]
        public string? FlightNumber { get; set; } = null;

        /// <summary>
        /// The route type of the flight.
        /// </summary>
        [JsonProperty("route_type")]
        public string? RouteType { get; set; } = null;

        /// <summary>
        /// Indicates seat class (first class, business class, etc.).
        /// </summary>
        [JsonProperty("seat_class")]
        public string? SeatClass { get; set; } = null;

        /// <summary>
        /// Indicates whether a stopover is allowed on this ticket.
        /// </summary>
        [JsonProperty("stop_over")]
        public bool? StopOver { get; set; } = null;

        /// <summary>
        /// Amount of the taxes for current leg of the trip.
        /// </summary>
        [JsonProperty("tax_amount")]
        public long? TaxAmount { get; set; } = null;
    }
}