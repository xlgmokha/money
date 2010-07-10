using MoMoney.Domain.Core;

namespace tests.unit.client.domain.core
{
    public class RankingSpecs
    {
        [Concern(typeof (Ranking<>))]
        public abstract class behaves_like_a_list_of_calgary_flames_point_leaders : runner<Ranking<string>>
        {
            after_the_sut_has_been_created c = () =>
            {
                sut.add("Jarome Iginla");
                sut.add("Mike Cammalleri");
                sut.add("Daymond Langkow");
                sut.add("Todd Bertuzzi");
                sut.add("Rene Bourque");
                sut.add("Dion Phaneuf");
                sut.add("Craig Conroy");
                sut.add("Curtis Glencross");
                sut.add("David Moss");
                sut.add("Adrian Aucoin");
            };
        }

        public class when_someone_ranked_higher_is_compared_with_someone_ranked_lower :
            behaves_like_a_list_of_calgary_flames_point_leaders
        {
            it the_higher_ranked_player_should_be_revealed = () => result.should_be_greater_than(0);

            because b = () =>
            {
                result = sut.Compare("Jarome Iginla", "Mike Cammalleri");
            };

            static int result;
        }

        public class when_someone_ranked_lower_is_compared_with_someone_ranked_higher :
            behaves_like_a_list_of_calgary_flames_point_leaders
        {
            it the_lower_ranked_player_should_be_revealed = () => result.should_be_less_than(0);

            because b = () =>
            {
                result = sut.Compare("Mike Cammalleri", "Jarome Iginla");
            };

            static int result;
        }

        public class when_a_ranked_player_is_compared_with_them_selves :
            behaves_like_a_list_of_calgary_flames_point_leaders
        {
            it should_indicate_that_they_are_ranked_the_same = () => result.should_be_equal_to(0);

            because b = () =>
            {
                result = sut.Compare("David Moss", "David Moss");
            };

            static int result;
        }

        public class when_an_unranked_player_is_compared_to_a_ranked_player :
            behaves_like_a_list_of_calgary_flames_point_leaders
        {
            it should_ranked_the_ranked_player_higher = () => result.should_be_less_than(0);

            because b = () =>
            {
                result = sut.Compare("Brett Sutter", "Jarome Iginla");
            };

            static int result;
        }

        public class when_an_ranked_player_is_compared_to_a_unranked_player :
            behaves_like_a_list_of_calgary_flames_point_leaders
        {
            it should_ranked_the_ranked_player_higher = () => result.should_be_greater_than(0);

            because b = () =>
            {
                result = sut.Compare("Jarome Iginla", "Brett Sutter");
            };

            static int result;
        }
    }
}