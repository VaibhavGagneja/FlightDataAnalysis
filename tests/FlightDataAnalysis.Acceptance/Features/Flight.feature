Feature: Flight

I want to make sure that rest APIs for Flight works as expected

Scenario: Get all flights
	When When Flight details api is called
	Then The system returns the flight details
    | Id   | AircraftRegistrationNumber | AircraftType | FlightNumber | DepartureAirport | DepartureDatetime   | ArrivalAirport | ArrivalDatetime     |
    | 1    | ZX-IKD                     | 350          | M645         | HEL              | 2024-01-02 21:46:27 | DXB            | 2024-01-03 02:31:27 |
    | 996  | G-DIX                      | 320          | AY120        | HEL              | 2024-01-30 14:00:00 | OUL            | 2024-01-30 15:30:00 |
    | 997  | G-DIX                      | 320          | AY120        | HEL              | 2024-01-30 17:00:00 | OUL            | 2024-01-30 18:30:00 |
    | 994  | G-DIX                      | 320          | AY120        | HEL              | 2024-01-30 08:00:00 | OUL            | 2024-01-30 09:30:00 |
    | 995  | G-DIX                      | 320          | AY120        | OUL              | 2024-01-30 11:00:00 | HEL            | 2024-01-30 12:30:00 |
    | 999  | C-RIB                      | 320          | AY123        | AMS              | 2023-05-08 11:00:00 | HEL            | 2023-05-08 14:30:00 |
    | 998  | C-RIB                      | 320          | AY123        | HEL              | 2023-05-08 08:00:00 | AMS            | 2023-05-08 11:30:00 |
    | 1000 | C-RIB                      | 320          | AY123        | HEL              | 2023-05-08 14:00:00 | AMS            | 2023-05-08 17:30:00 |


Scenario: Get flight by id when flight does not existWhen Flight details api is called by flight id "1"
    When Flight details api is called by flight id "1121212"
    Then The system returns the entity not found for entity "Flight" and entity id "1121212"

Scenario: Get flight by id
    When Flight details api is called by flight id "1"
    Then The system returns the flight detail
    | Id   | AircraftRegistrationNumber | AircraftType | FlightNumber | DepartureAirport | DepartureDatetime   | ArrivalAirport | ArrivalDatetime     |
    | 1    | ZX-IKD                     | 350          | M645         | HEL              | 2024-01-02 21:46:27 | DXB            | 2024-01-03 02:31:27 |

Scenario: Get flight options 
    When Flight options api is called 
    Then The system returns the flight options
    | Id   | AircraftRegistrationNumber |
    | 1    | ZX-IKD                     |
    | 996  | G-DIX                      |
    | 997  | G-DIX                      |
    | 994  | G-DIX                      |
    | 995  | G-DIX                      |
    | 999  | C-RIB                      |
    | 998  | C-RIB                      |
    | 1000 | C-RIB                      |

Scenario: Get flight by pagination 
    When Flight paged api is called by page size "2" page number "1"
    Then The system returns the flight details total pages "4" total count "8" and page size "2"
    | Id   | AircraftRegistrationNumber | AircraftType | FlightNumber | DepartureAirport | DepartureDatetime   | ArrivalAirport | ArrivalDatetime     |
    | 1    | ZX-IKD                     | 350          | M645         | HEL              | 2024-01-02 21:46:27 | DXB            | 2024-01-03 02:31:27 |
    | 996  | G-DIX                      | 320          | AY120        | HEL              | 2024-01-30 14:00:00 | OUL            | 2024-01-30 15:30:00 |
