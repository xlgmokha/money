namespace MoMoney.boot.container.registration.mapping
{
    public class MappingStep<Input, Output, Type> : IMappingStep<Input, Output>
    {
        readonly ISourceEvaluator<Input, Type> input_evaluator;
        readonly ITargetAction<Output, Type> action_to_run_against_destination;

        public MappingStep(ISourceEvaluator<Input, Type> source_evaluator, ITargetAction<Output, Type> target_action)
        {
            input_evaluator = source_evaluator;
            action_to_run_against_destination = target_action;
        }

        public void map(Input input, Output destination)
        {
            var value_pulled_from_input_item = input_evaluator.evaluate_against(input);
            action_to_run_against_destination.act_against(destination, value_pulled_from_input_item);
        }
    }
}