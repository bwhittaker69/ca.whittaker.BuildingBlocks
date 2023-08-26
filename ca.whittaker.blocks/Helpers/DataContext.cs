namespace ca.whittaker.blocks.Helpers;

using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

public class DataContext
{
    private DbSettings _dbSettings;

    public DataContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        return new NpgsqlConnection(connectionString);
    }

    public async Task Init()
    {
        await _initDatabase();
        await _initTables();
    }

    private async Task _initDatabase()
    {
        // create database if it doesn't exist
        var connectionString = $"Host={_dbSettings.Server}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        using var connection = new NpgsqlConnection(connectionString);
        var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{_dbSettings.Database}';";
        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
        if (dbCount == 0)
        {
            var sql = $"CREATE DATABASE \"{_dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
        }
    }

    private async Task _initTables()
    {
        // create tables if they don't exist
        using var connection = CreateConnection();
        await _initSQL();

        async Task _initSQL()
        {
            var sql = """
            
                CREATE SCHEMA IF NOT EXISTS buildingblocks AUTHORIZATION postgres;

                -- ***********************************
                -- Table: buildingblocks.blocktypes
                -- ***********************************
                CREATE TABLE IF NOT EXISTS buildingblocks.blocktypes
                (
                    id BIGSERIAL NOT NULL,
            	    name text NOT NULL,
                    icon bytea null,
                    backgroundcolor VARCHAR(7) null,
                    bordercolor VARCHAR(7) null,
                    fontcolor VARCHAR(7) null,
                    border INT null,
                    margin INT null,
                    CONSTRAINT blocktype_pkey PRIMARY KEY (id)
                )

                TABLESPACE pg_default;

                ALTER TABLE IF EXISTS buildingblocks.blocktypes OWNER to postgres;

                ALTER TABLE buildingblocks.blocktypes ADD CONSTRAINT bordercolor_hex_constraint CHECK (bordercolor is null or bordercolor ~* '^#[a-f0-9]{6}$');
                ALTER TABLE buildingblocks.blocktypes ADD CONSTRAINT fontcolor_hex_constraint CHECK (fontcolor is null or fontcolor ~* '^#[a-f0-9]{6}$');
                ALTER TABLE buildingblocks.blocktypes ADD CONSTRAINT backgroundcolor_hex_constraint CHECK (backgroundcolor is null or backgroundcolor ~* '^#[a-f0-9]{6}$');

                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('LineOfBusiness', 100);
                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('Enterprise',200);
                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('Segment',300);
                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('Intiative',400);
                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('Architecture',500);
                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('Technology',600);
                INSERT INTO buildingblocks.blocktypes(name, id)	VALUES ('Solution',700);


                -- ***********************************
                -- Table: buildingblocks.blocks
                -- ***********************************
                CREATE TABLE IF NOT EXISTS buildingblocks.blocks
                (
                    id BIGSERIAL NOT NULL,
                    name VARCHAR(256) COLLATE pg_catalog."default" NOT NULL,
                    domain VARCHAR(256) COLLATE pg_catalog."default" NOT NULL,
                    description TEXT COLLATE pg_catalog."default" NOT NULL,
                    icon bytea null,
                    blocktypeid BIGINT null,
                    backgroundcolor VARCHAR(7) null,
                    bordercolor VARCHAR(7) null,
                    fontcolor VARCHAR(7) null,
                    border INT null,
                    margin INT null,
                    parentblockid BIGINT null,
                    childblockid BIGINT null,
                    CONSTRAINT block_has_blocktype FOREIGN KEY (blocktypeid)
                        REFERENCES buildingblocks.blocktypes (id) MATCH SIMPLE
                        ON UPDATE NO ACTION
                        ON DELETE NO ACTION
                        NOT VALID,
                    CONSTRAINT block_pkey PRIMARY KEY (id)	
                )

                TABLESPACE pg_default;

                ALTER TABLE IF EXISTS buildingblocks.blocks
                    OWNER to postgres;

                ALTER TABLE buildingblocks.blocks
                ADD CONSTRAINT block_has_parentblock FOREIGN KEY (parentblockid)
                        REFERENCES buildingblocks.blocks (id) MATCH SIMPLE
                        ON UPDATE NO ACTION
                        ON DELETE NO ACTION
                        NOT VALID;

                ALTER TABLE buildingblocks.blocks
                ADD CONSTRAINT bordercolor_hex_constraint
                CHECK (bordercolor is null or bordercolor ~* '^#[a-f0-9]{6}$');

                ALTER TABLE buildingblocks.blocks
                ADD CONSTRAINT fontcolor_hex_constraint
                CHECK (fontcolor is null or fontcolor ~* '^#[a-f0-9]{6}$');

                ALTER TABLE buildingblocks.blocks
                ADD CONSTRAINT backgroundcolor_hex_constraint
                CHECK (backgroundcolor is null or backgroundcolor ~* '^#[a-f0-9]{6}$');

            
            """;
            await connection.ExecuteAsync(sql);
        }
    }
}