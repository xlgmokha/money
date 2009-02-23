using System;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Domain.Core;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Domain.accounting.billing
{
    public class company_specs
    {}

    [Concern(typeof (company))]
    public class when_a_company_issues_a_bill_to_a_customer : old_context_specification<ICompany>
    {
        [Observation]
        public void it_should_issue_the_bill_to_the_customer_for_the_previous_billing_month()
        {
            customer.was_told_to(x => x.recieve(bill));
        }

        protected override ICompany context()
        {
            customer = an<IAccountHolder>();
            for_amount = new money(53, 24);
            that_is_due_on = new DateTime(2008, 02, 12);
            var the_company_to_pay = new company("enmax");

            bill = new bill(the_company_to_pay, for_amount, that_is_due_on);
            return the_company_to_pay;
        }

        protected override void because()
        {
            sut.issue_bill_to(customer, that_is_due_on, for_amount);
        }

        private IAccountHolder customer;
        private IMoney for_amount;
        private DateTime that_is_due_on;
        private IBill bill;
    }

    [Concern(typeof (company))]
    public class when_a_company_pays_an_employee_or_consultant_for_services : old_context_specification<ICompany>
    {
        [Observation]
        public void it_should_pay_the_total_amount_that_is_due()
        {
            person.was_told_to(x => x.recieve(new income(date_of_payment, two_thousand_dollars, sut)));
        }

        protected override ICompany context()
        {
            two_thousand_dollars = new money(2000);
            person = an<IAccountHolder>();
            date_of_payment = an<IDate>();

            return new company("eCompliance");
        }

        protected override void because()
        {
            sut.pay(person, two_thousand_dollars, date_of_payment);
        }

        private money two_thousand_dollars;
        private IAccountHolder person;
        private IDate date_of_payment;
    }
}