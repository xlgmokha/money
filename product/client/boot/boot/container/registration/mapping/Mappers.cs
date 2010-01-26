using gorilla.commons.utility;
using MoMoney.Domain.Accounting;
using MoMoney.DTO;

namespace MoMoney.boot.container.registration.mapping
{
    public class Mappers
    {
        static public Mapper<Bill, BillInformationDTO> bill_mapper =
            new Map<Bill, BillInformationDTO>()
                .initialize_mapping_using(() => new BillInformationDTO())
                .map(x => x.company_to_pay.name, y => y.company_name)
                .map(x => x.the_amount_owed.ToString(), y => y.the_amount_owed)
                .map(x => x.due_date.to_date_time(), y => y.due_date);
    }
}