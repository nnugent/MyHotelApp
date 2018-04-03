namespace MyHotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStates : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE States ADD code VARCHAR(50)");
            Sql("insert into states(code, name) values('AL', 'Alabama')");
            Sql("insert into states(code, name) values('AK', 'Alaska')");
            Sql("insert into states(code, name) values('AS', 'American Samoa')");
            Sql("insert into states(code, name) values('AZ', 'Arizona')");
            Sql("insert into states(code, name) values('AR', 'Arkansas')");
            Sql("insert into states(code, name) values('CA', 'California')");
            Sql("insert into states(code, name) values('CO', 'Colorado')");
            Sql("insert into states(code, name) values('CT', 'Connecticut')");
            Sql("insert into states(code, name) values('DE', 'Delaware')");
            Sql("insert into states(code, name) values('DC', 'District of Columbia')");
            Sql("insert into states(code, name) values('FM', 'Federated States of Micronesia')");
            Sql("insert into states(code, name) values('FL', 'Florida')");
            Sql("insert into states(code, name) values('GA', 'Georgia')");
            Sql("insert into states(code, name) values('GU', 'Guam')");
            Sql("insert into states(code, name) values('HI', 'Hawaii')");
            Sql("insert into states(code, name) values('ID', 'Idaho')");
            Sql("insert into states(code, name) values('IL', 'Illinois')");
            Sql("insert into states(code, name) values('IN', 'Indiana')");
            Sql("insert into states(code, name) values('IA', 'Iowa')");
            Sql("insert into states(code, name) values('KS', 'Kansas')");
            Sql("insert into states(code, name) values('KY', 'Kentucky')");
            Sql("insert into states(code, name) values('LA', 'Louisiana')");
            Sql("insert into states(code, name) values('ME', 'Maine')");
            Sql("insert into states(code, name) values('MH', 'Marshall Islands')");
            Sql("insert into states(code, name) values('MD', 'Maryland')");
            Sql("insert into states(code, name) values('MA', 'Massachusetts')");
            Sql("insert into states(code, name) values('MI', 'Michigan')");
            Sql("insert into states(code, name) values('MN', 'Minnesota')");
            Sql("insert into states(code, name) values('MS', 'Mississippi')");
            Sql("insert into states(code, name) values('MO', 'Missouri')");
            Sql("insert into states(code, name) values('MT', 'Montana')");
            Sql("insert into states(code, name) values('NE', 'Nebraska')");
            Sql("insert into states(code, name) values('NV', 'Nevada')");
            Sql("insert into states(code, name) values('NH', 'New Hampshire')");
            Sql("insert into states(code, name) values('NJ', 'New Jersey')");
            Sql("insert into states(code, name) values('NM', 'New Mexico')");
            Sql("insert into states(code, name) values('NY', 'New York')");
           Sql("insert into states(code, name) values('NC', 'North Carolina')");
            Sql("insert into states(code, name) values('ND', 'North Dakota')");
            Sql("insert into states(code, name) values('MP', 'Northern Mariana Islands')");
            Sql("insert into states(code, name) values('OH', 'Ohio')");
            Sql("insert into states(code, name) values('OK', 'Oklahoma')");
            Sql("insert into states(code, name) values('OR', 'Oregon')");
            Sql("insert into states(code, name) values('PW', 'Palau')");
            Sql("insert into states(code, name) values('PA', 'Pennsylvania')");
            Sql("insert into states(code, name) values('PR', 'Puerto Rico')");
            Sql("insert into states(code, name) values('RI', 'Rhode Island')");
            Sql("insert into states(code, name) values('SC', 'South Carolina')");
            Sql("insert into states(code, name) values('SD', 'South Dakota')");
            Sql("insert into states(code, name) values('TN', 'Tennessee')");
            Sql("insert into states(code, name) values('TX', 'Texas')");
            Sql("insert into states(code, name) values('UT', 'Utah')");
            Sql("insert into states(code, name) values('VT', 'Vermont')");
            Sql("insert into states(code, name) values('VI', 'Virgin Islands')");
            Sql("insert into states(code, name) values('VA', 'Virginia')");
            Sql("insert into states(code, name) values('WA', 'Washington')");
            Sql("insert into states(code, name) values('WV', 'West Virginia')");
            Sql("insert into states(code, name) values('WI', 'Wisconsin')");
            Sql("insert into states(code, name) values('WY', 'Wyoming')");
        }
        
        public override void Down()
        {
        }
    }
}
