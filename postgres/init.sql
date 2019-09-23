CREATE TABLE test_table(id SERIAL PRIMARY KEY, name VARCHAR);

insert into test_table(name) values('oskar');
insert into test_table(name) values('test');

CREATE TABLE events
(
    id uuid NOT NULL,
    aggregatetype character varying(255) COLLATE pg_catalog."default" NOT NULL,
    aggregateid character varying(255) COLLATE pg_catalog."default" NOT NULL,
    type character varying(255) COLLATE pg_catalog."default" NOT NULL,
    payload jsonb NOT NULL,
    CONSTRAINT events_pkey PRIMARY KEY (id)
);

INSERT INTO public.events(
	id, aggregatetype, aggregateid, type, payload)
	VALUES ('2d5b074d-b1c9-48da-a88a-e5f03597b134', 'User', '4a9e4159-0251-4307-84c8-4c6c9d10bd2e', 'UserCreated', '{"Name": "John Doe"}');
    
INSERT INTO public.events(
	id, aggregatetype, aggregateid, type, payload)
	VALUES ('e7e74c0c-1f2f-404a-824d-1b1d434810b7', 'User', '9a0af90b-288b-454d-94e4-a44574748db6', 'UserCreated', '{"Name": "Annie Hall"}');

CREATE SCHEMA testevents;

CREATE TABLE testevents.mt_events
(
    seq_id bigint NOT NULL,
    id uuid NOT NULL,
    stream_id uuid,
    version integer NOT NULL,
    data jsonb NOT NULL,
    type character varying(500) COLLATE pg_catalog."default" NOT NULL,
    "timestamp" timestamp with time zone NOT NULL DEFAULT now(),
    tenant_id character varying COLLATE pg_catalog."default" DEFAULT '*DEFAULT*'::character varying,
    mt_dotnet_type character varying COLLATE pg_catalog."default",
    CONSTRAINT pk_mt_events PRIMARY KEY (seq_id)
);

INSERT INTO testevents.mt_events(
	seq_id, id, stream_id, version, data, type, "timestamp", tenant_id, mt_dotnet_type)
	VALUES (0, '1915d7de-3482-4d3a-b072-109e41e5cb0d', '9a0af90b-288b-454d-94e4-a44574748db6', 1, '{"Name": "Annie Hall"}', 'meeting_created', '2019-09-21 11:16:47.606273+00', 'DEFAULT', 'Marten.WebApi.Meetings.Events.MeetingCreated, Marten.WebApi');

