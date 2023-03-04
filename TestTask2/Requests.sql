-- List of tickets of the client with his/her info.
SELECT tickets.ticket_id, tickets.seat_number, clients.first_name, clients.last_name, clients.email, clients.phone
FROM tickets
JOIN bookings ON tickets.booking_id = bookings.booking_id
JOIN clients ON bookings.client_id = clients.client_id
WHERE clients.client_id = 'CL00000000000001';

-- Last 5 sold tickets
SELECT tickets.ticket_id, bookings.date_booked, bookings.time_booked, flights.departure_date, flights.departure_time, airports.name as departure_airport,
       flights.arrival_date, flights.arrival_time, airports2.name as arrival_airport
FROM tickets
JOIN bookings ON bookings.booking_id = tickets.booking_id
JOIN flights ON flights.flight_id = bookings.flight_id
JOIN airports ON airports.airport_id = flights.departure_airport_id
JOIN airports as airports2 ON airports2.airport_id = flights.arrival_airport_id
ORDER BY bookings.date_booked DESC, bookings.time_booked DESC
LIMIT 5;

-- Top 3 clients by flights count
SELECT clients.client_id, clients.first_name, clients.last_name, clients.email, clients.phone, COUNT(*) as num_flights
FROM clients
JOIN bookings ON bookings.client_id = clients.client_id
GROUP BY clients.client_id
ORDER BY num_flights DESC
LIMIT 3;