namespace MoMoney.Utility.Core
{
    public class chained_mapper<Left, Middle, Right> : IMapper<Left, Right>
    {
        private readonly IMapper<Left, Middle> left;
        private readonly IMapper<Middle, Right> right;

        public chained_mapper(IMapper<Left, Middle> left, IMapper<Middle, Right> right)
        {
            this.left = left;
            this.right = right;
        }

        public Right map_from(Left item)
        {
            return right.map_from(left.map_from(item));
        }
    }
}