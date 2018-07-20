
namespace AltitudeAngel
{
    /**
       https://developers.altitudeangel.com/docs#auth_overview

       INVESTIGATE: Don't think there is an API that uses these scopes, or any
       way for a User to get their current scopes for a provided API key !?
     */
    enum Scopes
    {
        query_mapdata,  // Query the map endpoints for ground data. API Key: Y
        query_mapairdata,  // Query the map endpoints for airspace data. API Key: Y
        talk_tower  // Query the area report and weather endpoints. API Key: Y
    }


    /**
       https://developers.altitudeangel.com/docs#types_activity
    */
    enum Activity
    {
        AD_TFC,  // All traffic on the manoeuvring area of an aerodrome and all aircraft flying in the vicinity of an aerodrome.(Annex11).
        HELI_TFC,  // Helicopter or gyrocopter operations.
        TRAINING,  // Flights conducted for the purpose of training.
        AEROBATICS,  // The usage of unusual or artful flying manoeuvres for recreation, competition, or entertainment.
        AIRSHOW,  // A show at which aircraft are on view and featuring aerial displays.
        SPORT,  // The competition or practice by an individual or a group to achieve the best aerial performance. A type of special air traffic. This could be an air race or aerobatic training or competition.
        ULM,  // Ultra light flights.
        GLIDING,  // Flying a non-power-driven heavier-than-air aircraft.
        PARAGLIDER,  // Recreational and competitive flying sport using a free-flying, foot launched aircraft.
        HANGGLIDING,  // Recreational and competitive flying sport using a small glider from which the operator is suspended in a frame and which is controlled by movements of the body.
        PARACHUTE,  // Exiting a flying aircraft by an individual using a parachute.
        AIR_DROP,  // The dropping of troops, supplies, bombs, etc., from an aircraft.
        BALLOON,  // Flight activity involving a bag called the envelope that is capable of containing heated air, with a gondola or basket suspended beneath.
        RADIOSONDE,  // The lifting of devices through the atmosphere, which are tied to a helium or hydrogen filled balloon. A type of special air traffic. Radio probe and meteorological balloons are examples.
        SPACE_FLIGHT,  // Vertical launch for space flight operations.
        UAV,  // The operation of a powered, aerial vehicle that does not carry a human operator.
        AERIAL_WORK,  // Operations in which an aircraft is used for specialized services. A type of special air traffic. Services such as agriculture, construction, photography, surveying, observation and patrol, search and rescue, aerial advertisement, etc. are examples.
        CROP_DUSTING,  // Spraying crops with fertilizers, pesticides, and fungicides from an agricultural aircraft.
        FIRE_FIGHTING,  // Intense fire fighting activity involving chemical agents being laid down from fire fighting aircraft.
        MILOPS,  // The execution of operations by the military.
        REFUEL,  // Transfer of fuel between aircraft in the air.
        JET_CLIMBING,  // Climb-out of jet aircraft via predefined and common tracks.
        EXERCISE,  // Intercepting and destroying of hostile aircraft or conducting similar training activities.
        TOWING,  // Drawing or pulling through the air a target for aerial shooting practice.
        NAVAL_EXER,  // Naval forces (for example: vessels or aircraft) conduct firing and/or munitions exercises.
        MISSILES,  // The launch, transit, and targeting of guided missiles.
        AIR_GUN,  // The delivery of air to air or air to ground weapons for the destruction of a target.
        ARTILLERY,  // The discharge of a projectile into the air for the destruction of a target.
        SHOOTING,  // The discharge of a gun or bow to propel arrows, bullets, etc swiftly or violently direct and sharply in specified directions. 
        BLASTING,  // Controlled use of explosives to excavate or remove rock.
        WATER_BLASTING,  // The action or an act of forcing out or emitting something suddenly underwater.
        ANTI_HAIL,  // The use of small rockets to protect crops by seeding clouds with small particles that prevent hailstorms from forming.
        BIRD,  // Bird hazard.
        BIRD_MIGRATION,  // A high number of bird species as they fly instinctual routes based on breeding or diverse environmental urges.
        FIREWORK,  // Launching of pyrotechnic devices.
        HI_RADIO,  // Electromagnetic fields produced by high intensity radio transmission.
        HI_LIGHT,  // Non-navigational lights with high visibility potential.
        LASER,  // A type of hazard. Laser stands for Light Amplification by Stimulated Emission of Radiation. An example is a laser light show.
        NATURE,  // Wildlife, flora, fauna or features of geological or other special interest which is reserved and managed for conservation.
        FAUNA,  // The animals or animal life of a given area, habitat, or epoch which is easily and dangerously aroused by excessive aerial noise such as from an aircraft. A type of protection. Examples include mink or turkey farms and zoos.
        NO_NOISE,  // Airspace in which special procedures or other precautionary measures are established for reducing noise.
        ACCIDENT,  // Airspace needing a protective status due to an investigation of a flight catastrophe.
        POPULATION,  // An area with a high concentration of inhabitants.
        VIP,  // The presence of an individual of renowned status and considered as a very important person.
        VIP_PRES,  // The presence of an individual with status of head of state.
        VIP_VICE,  // The presence of an individual with status of Vice-Head of State.
        OIL,  // An area in which oil occurs in quantities worthy of exploitation.
        GAS,  // Pumping natural gas from the ground or converting gasoline into vapour.
        REFINERY,  // A facility where petroleum and/or petroleum products are refined.
        CHEMICAL,  // A facility utilizing a chemical process for manufacturing.
        NUCLEAR,  // An installation which provides power, derived from fission or fusion of atomic nuclei.
        TECHNICAL,  // Generic technical activity affecting air traffic.
        // .  // TODO: Ask the guy's at Altitude Angel why there is a random full-stop in their spec here??
        ATS,  // Custom specific flight information service, alerting service, air traffic advisory service, air traffic control service, area control service, approach control service, or airport control service is provided.
        PROCEDURE,  // Special procedures established for use by operational personnel in execution of their flight. A type of procedure/service. An overhead approach is an example of a special procedure.
        OTHER  // Other
    }


    /**
       https://developers.altitudeangel.com/docs#types_airspace

       FIXME: Can't do enums with colon in the middle. Might have to change to
       nested static classes like this:
       https://stackoverflow.com/questions/980766/how-do-i-declare-a-nested-enum#24969525
    */
/*    enum Airspace
    {
        airport:aerodrome,  // The region around an aerodrome that local regulations control flying a drone
        airport:gliderport,  // The region around an glider port that local regulations control flying a drone
        airport:heliport,  // The region around an heliport that local regulations control flying a drone
        airport:seaplane,  // The region around an seaplane port that local regulations control flying a drone
        class:a,  // An area of airspace designated as Class A airspace
        class:b,  // An area of airspace designated as Class B airspace
        class:c,  // An area of airspace designated as Class C airspace
        class:d,  // An area of airspace designated as Class D airspace
        class:e,  // An area of airspace designated as Class E airspace
        class:f,  // An area of airspace designated as Class F airspace
        other:us_national_park,  // A US National Park. Only used in contiguous United States and its territories.
        type:a,  // Alert area. Airspace which may contain a high volume of pilot training activities or unusual type of aerial activity, neither of which is hazardous to aircraft. Mainly used in contiguous United States and its territories.
        type:adiz,  // Air Defence Identification Zone. Special designated airspace of defined dimensions within which aircraft are required to comply with special identification and/or reporting procedures additional to those related to the provision of air traffic services (ATS).
        type:adv,  // Advisory Area. An area of defined dimensions within which air traffic advisory service is available.
        type:ama	Minimum altitude area. The lowest altitude to be used under instrument meteorological conditions (IMC) which will provide a minimum vertical clearance of 300 m (1 000 ft) or in designated mountainous terrain 600 m (2 000 ft) above all obstacles located in the area specified.,  // Not currently returned
        type:asr	Altimeter setting region. Airspace of defined dimensions within which standardized altimeter setting procedures apply.,  // Not currently returned
        type:atz,  // Airport Traffic Zone. Airspace of defined dimensions established around an airport for the protection of airport traffic.
        type:atz_p,  // Part of an airport traffic zone
        type:awy	Airway (corridor). A control area or portion thereof established in the form of a corridor.,  // Not currently returned
        type:cba	Cross border area (FUA). Airspace of defined dimensions, above the land areas or territorial waters of more than one state.,  // Not currently returned
        type:cta,  // Control area. A controlled airspace extending upwards from a specified limit above the earth.
        type:cta_p,  // Part of a CTA.
        type:ctr,  // Control zone. A controlled airspace extending upwards from the surface of the earth to a specified upper limit.
        type:ctr_p,  // Part of a CTR.
        type:d,  // Danger area. Airspace of defined dimensions within which activities dangerous to the flight of aircraft may exist at specified times.
        type:d_other,  // Activities of dangerous nature (other than a danger area).
        type:faa:sua:aa,  // An Alert Area defined under the FAA's Special Use Airspace. Only used in contiguous United States and its territories.
        type:faa:sua:moa,  // A Military Operations Area defined under the FAA's Special Use Airspace. Only used in contiguous United States and its territories.
        type:faa:sua:nsa,  // A National Security Area defined under the FAA's Special Use Airspace. Only used in contiguous United States and its territories.
        type:faa:sua:pa,  // A Prohibited Area defined under the FAA's Special Use Airspace. Only used in contiguous United States and its territories.
        type:faa:sua:ra,  // A Restricted Area defined under the FAA's Special Use Airspace. Only used in contiguous United States and its territories.
        type:faa:sua:wa,  // A Warning Area defined under the FAA's Special Use Airspace. Only used in contiguous United States and its territories.
        type:fir	Flight information region. Airspace of defined dimensions within which flight information service and alerting service are provided.,  // Not currently returned
        type:fir_p	Part of an FIR.,  // Not currently returned
        type:htz,  // Helicopter traffic zone
        type:mtr,  // Military Training Route buffer. A control area or portion thereof, established in the form of a corridor around a military training route in order to protect it from other traffic.
        type:nas,  // National Airspace System. [note: The airspace within which a State provides Air Traffic Services is usually composed of:1) the territories over which the State has jurisdiction;2) those portions of the airspace over the high seas or in airspace of undetermined sovereignty where the provision of ATS are provided as determined by regional agreements. It can usually be determined by the UNION of FIRs (including, where appropriate, NO-FIRs) of the UNION of NAS-P. .] 
        type:nas_p,  // A part of a national airspace system
        type:nav_warning,  // A NOTAM issued Naviation Warning
        type:no_drone,  // An area that the regulatory authority has declared to be a no fly zone for drones
        type:no_fir,  // Airspace for which not even an FIR is defined.
        type:oca,  // Oceanic control area. A Control Area extending upwards in the upper airspace.
        type:oca_p,  // Part of an OCA.
        type:ota,  // Oceanic transition area.
        type:other,  // Other
        type:p,  // Prohibited area. Airspace of defined dimensions, above the land areas or territorial waters of a State, within which the flight of aircraft is prohibited.
        type:part,  // Part of an airspace (used in airspace aggregation). Not currently returned
        type:political,  // Political/administrative area.
        type:protect,  // Airspace protected from specific air traffic.
        type:r,  // Restricted area. Airspace of defined dimensions, above the land areas or territorial waters of a State, within which the flight of aircraft is restricted in accordance with certain specified conditions.
        type:ras,  // Regulated airspace (not otherwise covered).
        type:rca,  // Reduced co-ordination area (FUA). Portion of airspace of defined dimensions within which general aviation traffic is permitted "off-route" without requiring general aviation traffic controllers to initiate co-ordination with OAT controllers. Mainly used in Europe under the Flexible Use of Airspace concept.
        type:sector	Control sector. A subdivision of a designated control area within which responsibility is assigned to one controller or to a small group of controllers.,  // Not currently returned
        type:sector_c	Temporary consolidated (collapsed) sector.,  // Not currently returned
        type:tfr,  // Temporary Flight Restriction. Typically enforced by NOTAM
        type:tma,  // Terminal control area. Control area normally established at the confluence of ATS routes in the vicinity of one or more major aerodromes.
        type:tma_p,  // Part of a TMA.
        type:tra,  // Temporary reserved area (FUA). Airspace of pre-defined dimensions within which activities require the reservation of airspace during a predetermined period of time. Mainly used in Europe under the Flexible Use of Airspace concept.
        type:tsa,  // Temporary segregated area (FUA). Airspace of pre-defined dimensions within which activities require the reservation of airspace for the exclusive use of specific users during a predetermined period of time.
        type:uadv,  // Upper Advisory Area. An area of defined dimensions in upper airspace within which air traffic advisory service is available.
        type:uir	Upper flight information region. An upper airspace of defined dimensions within which flight information service and alerting service are provided.,  // Not currently returned
        type:uir_p	Part of a UIR.,  // Not currently returned
        type:uta,  // Upper control area. A Control Area extending upwards in the upper airspace.
        type:uta_p,  // Part of a UTA.
        type:w,  // Warning area. A non-regulatory airspace of defined dimensions designated over international waters that contains activity which may be hazardous to aircraft not participating in the activity. The purpose of such warning areas is to warn non participating pilots of the potential danger.
        risk:GasVentingStation,  // A Gas venting station
        risk:increasedAerialActivity:airport,  // An airport
        risk:increasedAerialActivity:balloonSite,  // A ballooning site
        risk:increasedAerialActivity:gliderSite,  // A Glider site
        risk:increasedAerialActivity:hanggliderSite,  // Hanggliding site
        risk:increasedAerialActivity:kiteFlyingSite,  // Kite flying site
        risk:increasedAerialActivity:parachute,  // Parachute jumping
        risk:increasedAerialActivity:ultraLights,  // a site with increase aerial activity from ultra lights
        risk:increasedAerialActivity:unusualActivity,  // A site of unusual aerial activity
        risk:radioInterference:hirta,  // A site of high intensity radio transmissions
    }
*/

    /**
       https://developers.altitudeangel.com/docs#types_ground_hazards

       FIXME: Can't do enums with colon in the middle. Might have to change to
       nested static classes like this:
       https://stackoverflow.com/questions/980766/how-do-i-declare-a-nested-enum#24969525
    */
/*    enum GroundHazards
    {
        aerialway:cable_car,  // A cable car
        aerialway:chair_lift,  // A chair lift
        aerialway:drag_lift,  // A drag lift
        aerialway:gondola,  // A gondola
        aerialway:j-bar,  // A j-bar
        aerialway:mixed_lift,  // A mixed lift
        aerialway:platter,  // A platter
        aerialway:pylon,  // A pylon
        aerialway:rope_tow,  // A rope tow
        aerialway:station,  // A station
        aerialway:t-bar,  // A t-bar
        aerialway:zip_line,  // A zip line
        aeroway:aerodrome,  // An aerodrome
        aeroway:helipad,  // A helipad
        aeroway:heliport,  // A heliport
        aeroway:runway,  // A runway
        amenity:college,  // A college
        amenity:kindergarten,  // A kindergarten
        amenity:school,  // A school
        amenity:university,  // A university
        amenity:charging_station,  // A charging station
        amenity:fuel,  // A fuel station
        building:school,  // A school
        building:stadium,  // A stadium
        building:train_station,  // A train station
        building:greenhouse,  // A greenhouse
        building:transformer_tower,  // A transformer tower
        highway:motorway,  // A motorway
        highway:raceway,  // A raceway
        leisure:stadium,  // A stadium
        man_made:beacon,  // A beacon
        man_made:chimney,  // A chimney
        man_made:communications_tower,  // A communications tower
        man_made:crane,  // A crane
        man_made:mast,  // A mast
        man_made:tower,  // A tower
        man_made:water_tower,  // A water tower
        man_made:windmill,  // A windmill
        military:airfield,  // An airfield
        military:ammunition,  // An ammunition dump
        military:danger_area,  // A danger area
        military:range,  // A range
        power:plant,  // A power plant
        power:cable,  // A power cable
        power:converter,  // A power converter
        power:generator,  // A power generator
        power:heliostat,  // A heliostat
        power:line,  // A power line
        power:minor_line,  // A minor power line
        power:portal,  // A power portal
        power:substation,  // A substation
        power:tower,  // A tower
        power:transformer,  // A transformer
        sport:model_aerodrome,  // A model aerodrome
        sport:paragliding,  // A paragliding
        sport:kitesurfing,  // A kitesurfing
        sport:shooting,  // A shooting range
        landuse:military,  // A military establishment
        amenity:police,  // A police station
        amenity:fire_station,  // A fire station
        amenity:hospital,  // A hospital
        building:hospital,  // A hospital
        military:barracks,  // A military barracks
        military:training_area,  // A military training area
        military:naval_base,  // A naval base
        leisure:nature_reserve,  // A nature reserve
        man_made:gasometer,  // A gasometer
        man_made:lighthouse,  // A lighthouse
        railway:rail,  // A railway track
        railway:monorail,  // A monorail
        railway:funicular,  // A funicular
        railway:light_rail,  // A light rail
        railway:station,  // A station
        navigation:hazard,  // A hazard
        leisure:park,  // A park
        landuse:cemetery,  // A cemetery
        amenity:prison,  // A prison
        aeroway:gliderport,  // A gliderport
        aeroway:ultralights,  // An ultralights airfield
        aeroway:seaplane,  // A seaplane port
        aeroway:balloonport  // A balloonport
    }
*/

    public class AltitudeAngel
    {
        /**
           AltitudeAngel() - Constructor which handles all HttpClient sessions.
        */
        public AltitudeAngel()
        {
            // TODO: Take in API key.

            // TODO: Create a HttpClient instance stored on the object, that
            // applies the Auth header on each request.

            // TODO: Make constructor easy to mock out the network calls.
        }

        /**
              https://developers.altitudeangel.com/docs#apis_areareport
              GET https://api.altitudeangel.com/v2/preflight/areareports

              This endpoint will return data for the area specified by a bounding box.

              Querystring parameter	Description
              n	The north coordinate of the bounding box in degrees
              e	The east coordinate of the bounding box in degrees
              s	The south coordinate of the bounding box in degrees
              w	The west coordinate of the bounding box in degrees
              The area of the bounding box must be less than the maximum of 10,000,000,000m2 (100 km x 100 km)
        */
        public void GetAreaReport(double north, double east, double south, double west)
        {
            // TODO: Implement instance client to do GET call and return JSON/GeoJSON.
        }

        /**
          https://developers.altitudeangel.com/docs#apis_mapdata
          GET /v2/mapdata/geojson?n=51.46227963315035&e=-0.9569686575500782&s=51.450125805383585&w=-0.9857433958618458 HTTP/1.1
          Authorization: X-AA-ApiKey YOUR_API_KEYGET

        Request Details
        /v2/mapdata/geojson

        This endpoint will return data for the area specified by a bounding box, subject to maximum queryable area limits as defined above.

        Querystring parameter	Description
        n	The north coordinate of the bounding box in degrees
        e	The east coordinate of the bounding box in degrees
        s	The south coordinate of the bounding box in degrees
        w	The west coordinate of the bounding box in degrees
        */
        public void GetMapData(double north, double east, double south, double west)
        {
            // TODO: Implement instance client to do GET call and return JSON/GeoJSON.
        }

        /**
           https://developers.altitudeangel.com/docs#apis_spaceweather
           GET https://api.altitudeangel.com/v2/preflight/spaceweather
        */
        public void GetSpaceWeather()
        {
            // TODO: Implement instance client to do GET call and return JSON/GeoJSON.
        }

        /**
           https://developers.altitudeangel.com/docs#apis_weather
           GET https://api.altitudeangel.com/v2/preflight/weather

           Querystring parameter	Description
           lat	The latitude of the coordinate specified
           lng	The longitude of the coordindate specified
        */
        public void GetWeather(double lat, double lng)
        {
            // TODO: Implement instance client to do GET call and return JSON/GeoJSON.
        }
    }
}
