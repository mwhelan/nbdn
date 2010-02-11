using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            context c = () =>
            {
                request = an<Request>();
            };

            because b = () =>
            {
                command = sut.get_command_that_can_process(request);
            };


            it should_return_the_command_that_can_do_the_processing = () =>
            {
                command.should_not_be_null();
            };

            static Request request;
            static Command command;
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_attempting_to_get_a_command_for_a_request_that_cannot_be_handled : concern
        {
            context c = () =>
            {
            };

            because b = () =>
            {
            };


            it name_it = () =>
            {
            };

        }
    }
}