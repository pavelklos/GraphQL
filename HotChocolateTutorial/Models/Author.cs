using HotChocolate.Types.Relay;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System;
using NodaTime;

namespace HotChocolateTutorial.Models;

[GraphQLName("BookAuthor")]
public class Author
{
    [GraphQLType(typeof(IdType))]
    //[GraphQLType(typeof(UuidType))]
    //public int Id { get; set; }
    //public string { get; set; }
    //public Guid Id { get; set; } = Guid.NewGuid();
    public int Id { get; set; }

    //[GraphQLName("fullName")]
    [GraphQLName("fullName")]
    [GraphQLType(typeof(StringType))]
    public string Name { get; set; }

    // Ignoring fields
    [GraphQLIgnore]
    public string? Title { get; set; }

    // Additional Field
    public DateTime Now() => DateTime.Now;
    public DateTime NowUtc() => DateTime.Now.ToUniversalTime();
    public Duration GetDuration() => Duration.FromMinutes(3);
    public ZonedDateTime GetZonedDateTime() => ZonedDateTime.FromDateTimeOffset(DateTime.Now);

    // Scalars
    public string MyString { get; set; } = string.Empty;
    public bool MyBool { get; set; }
    public int MyInt { get; set; } = int.MaxValue;
    public float MyFloat { get; set; } = float.MaxValue;
    public double MyDouble { get; set; } = double.MaxValue;
    public decimal MyDecimal { get; set; } = decimal.MaxValue;

    // -----------------------------------------------------------------------------
    // [.NET Scalars]
    // -----------------------------------------------------------------------------
    // Byte         Byte
    // ByteArray    Base64 encoded array of bytes
    // Short        Signed 16-bit numeric non-fractional value
    // Long         Signed 64-bit numeric non-fractional value
    // Decimal      .NET Floating Point Type
    // Url          Url
    // Date         ISO-8601 date
    // TimeSpan     ISO-8601 duration
    // Uuid         GUID
    // Any          This type can be anything, string, int, list or object, etc.
    public TimeSpan MyTimeSpan { get; set; } = new TimeSpan();

    // -----------------------------------------------------------------------------
    // [HotChocolate.Types.Scalars]
    // -----------------------------------------------------------------------------
    // EmailAddress         Email address, represented as UTF-8 character sequences, as defined in RFC5322
    // HexColor             HEX color code
    // Hsl                  CSS HSL color as defined here
    // Hsla                 CSS HSLA color as defined here
    // IPv4                 IPv4 address as defined here
    // IPv6                 IPv6 address as defined in RFC8064
    // Isbn                 ISBN-10 or ISBN-13 number as defined here
    // Latitude             Decimal degrees latitude number
    // Longitude            Decimal degrees longitude number
    // LocalCurrency        Currency string
    // LocalDate            ISO date string, represented as UTF-8 character sequences yyyy-mm-dd, as defined in RFC3339
    // LocalTime            Local time string (i.e., with no associated timezone) in 24-hr HH:mm:ss
    // MacAddress           IEEE 802 48-bit(MAC-48/EUI-48) and 64-bit(EUI-64) Mac addresses, represented as UTF-8 character sequences, as defined in RFC7042 and RFC7043
    // NegativeFloat        Double‐precision fractional value less than 0
    // NegativeInt          Signed 32-bit numeric non-fractional with a maximum of -1
    // NonEmptyString       Non empty textual data, represented as UTF‐8 character sequences with at least one character
    // NonNegativeFloat     Double‐precision fractional value greater than or equal to 0
    // NonNegativeInt       Unsigned 32-bit numeric non-fractional value greater than or equal to 0
    // NonPositiveFloat     Double‐precision fractional value less than or equal to 0
    // NonPositiveInt       Signed 32-bit numeric non-fractional value less than or equal to 0
    // PhoneNumber          A value that conforms to the standard E.164 format as defined here
    // PositiveInt          Signed 32‐bit numeric non‐fractional value of at least the value 1
    // PostalCode           Postal code
    // Port                 TCP port within the range of 0 to 65535
    // Rgb                  CSS RGB color as defined here
    // Rgba                 CSS RGBA color as defined here
    // SignedByte           Signed 8-bit numeric non‐fractional value greater than or equal to -127 and smaller than or equal to 128.
    // UnsignedInt          Unsigned 32‐bit numeric non‐fractional value greater than or equal to 0
    // UnsignedLong         Unsigned 64‐bit numeric non‐fractional value greater than or equal to 0
    // UnsignedShort        Unsigned 16‐bit numeric non‐fractional value greater than or equal to 0 and smaller or equal to 65535.
    // UtcOffset            A value of format ±hh:mm
    [GraphQLType(typeof(EmailAddressType))]
    public string MyEmailAddress() => "test@example.com";

    // -----------------------------------------------------------------------------
    // [HotChocolate.Types.Scalars]
    // -----------------------------------------------------------------------------
    // DateTimeZone     A NodaTime DateTimeZone	    "Europe/Rome"
    // Duration         A NodaTime Duration	        "-123:07:53:10.019"
    // Instant          A NodaTime Instant	        "2020-02-20T17:42:59Z"
    // IsoDayOfWeek     A NodaTime IsoDayOfWeek     7
    // LocalDate        A NodaTime LocalDate	    "2020-12-25"
    // LocalDateTime    A NodaTime LocalDateTime	"2020-12-25T13:46:78"
    // LocalTime        A NodaTime LocalTime	    "12:42:13.03101"
    // OffsetDateTime   A NodaTime OffsetDateTime	"2020-12-25T13:46:78+02:35"
    // OffsetDate       A NodaTime OffsetDate	    "2020-12-25+02:35"
    // OffsetTime       A NodaTime OffsetTime	    "13:46:78+02:35"
    // Offset           A NodeTime Offset	        "+02:35"
    // Period           A NodeTime Period	        "P-3W3DT139t"
    // ZonedDateTime    A NodaTime ZonedDateTime    "2020-12-31T19:40:13 Asia/Kathmandu +05:45"
}
