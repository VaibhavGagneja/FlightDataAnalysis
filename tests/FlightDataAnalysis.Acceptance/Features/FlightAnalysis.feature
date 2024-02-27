Feature: FlightAnalysis

I want to make that rest api for flight analysis works as expected

Scenario: Flight analysis report
	When Flight analysis api is called
	Then The system returns the flight details
    | Id   | AircraftRegistrationNumber | AircraftType | FlightNumber | DepartureAirport | DepartureDatetime   | ArrivalAirport | ArrivalDatetime     |
    | 996  | G-DIX                      | 320          | AY120        | HEL              | 2024-01-30 14:00:00 | OUL            | 2024-01-30 15:30:00 |
    | 997  | G-DIX                      | 320          | AY120        | HEL              | 2024-01-30 17:00:00 | OUL            | 2024-01-30 18:30:00 |
    | 999  | C-RIB                      | 320          | AY123        | AMS              | 2023-05-08 11:00:00 | HEL            | 2023-05-08 14:30:00 |
    | 998  | C-RIB                      | 320          | AY123        | HEL              | 2023-05-08 08:00:00 | AMS            | 2023-05-08 11:30:00 |
    | 1000 | C-RIB                      | 320          | AY123        | HEL              | 2023-05-08 14:00:00 | AMS            | 2023-05-08 17:30:00 |
