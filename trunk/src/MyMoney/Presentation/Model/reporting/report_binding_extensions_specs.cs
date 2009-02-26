using System;
using DataDynamics.ActiveReports;
using jpboodhoo.bdd.contexts;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Model.reporting
{
    [Concern(typeof (report_binding_extensions))]
    public class when_binding_a_active_report_control_to_a_string_property_of_a_dto : concerns_for
    {
        it should_set_the_controls_datafield_property_to_the_name_of_the_dtos_property =
            () => control.was_told_to(x => x.DataField = "name");

        context c = () => { control = dependency<ARControl>(); };

        because b = () => control.bind_to<test_dto, string>(x => x.name);

        static ARControl control;
    }

    [Concern(typeof (report_binding_extensions))]
    public class when_binding_a_active_report_control_to_a_date_time_property_of_a_dto : concerns_for
    {
        it should_set_the_controls_datafield_property_to_the_name_of_the_dtos_property =
            () => control.was_told_to(x => x.DataField = "birthdate");

        context c = () => { control = dependency<ARControl>(); };

        because b = () => control.bind_to<test_dto, DateTime>(x => x.birthdate);

        static ARControl control;
    }

    public class test_dto
    {
        public string name { get; set; }
        public long age { get; set; }
        public DateTime birthdate { get; set; }
    }
}