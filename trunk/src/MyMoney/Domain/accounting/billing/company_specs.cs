using System;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Domain.Core;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Domain.accounting.billing
{
    [Concern(typeof (company))]
    public class behaves_like_a_company : concerns_for<ICompany>
    {
        protected string company_name;

        public override ICompany create_sut()
        {
            company_name = "enmax";
            return new company(company_name);
        }
    }

    public class when_a_company_issues_a_bill_to_a_customer : behaves_like_a_company
    {
        it should_issue_the_bill_to_the_customer_for_the_previous_billing_month =
            () => customer.was_told_to(x => x.recieve(new bill(sut, for_amount, that_is_due_on)));

        context c = () =>
                        {
                            customer = an<IAccountHolder>();
                            for_amount = new money(53, 24);
                            that_is_due_on = new DateTime(2008, 02, 12);
                        };

        because b = () => sut.issue_bill_to(customer, that_is_due_on, for_amount);

        static IAccountHolder customer;
        static IMoney for_amount;
        static DateTime that_is_due_on;
    }

    public class when_a_company_pays_an_employee_or_consultant_for_services : behaves_like_a_company
    {
        it should_pay_the_total_amount_that_is_due =
            () => person.was_told_to(x => x.recieve(new income(date_of_payment, two_thousand_dollars, sut)));

        context c = () =>
                        {
                            two_thousand_dollars = new money(2000);
                            person = an<IAccountHolder>();
                            date_of_payment = an<IDate>();
                        };

        because b = () => sut.pay(person, two_thousand_dollars, date_of_payment);

        static money two_thousand_dollars;
        static IAccountHolder person;
        static IDate date_of_payment;
    }
}