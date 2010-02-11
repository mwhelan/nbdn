using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ViewProductsSpec
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewProducts>
         {
        
         }

         [Concern(typeof(ViewProducts))]
         public class when_observation_name : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 repository = the_dependency<Repository>();
                 response_engine = the_dependency<ReponseEngine>();

                 departments = new List<Product>();

                 var department = an<SubDepartment>();
                 int department_id = 1;

                 request.Stub(x => x.item("sub_department_id")).Return((Object)(department_id));
                 repository.Stub(x => x.get_sub_department(department_id)).Return(department);
                 //repository.Stub(x => x.get_all_sub_departments_for(department)).Return(departments);
             };

             because b = () =>
             {
                 sut.process(request);
             };

             it should_tell_the_response_engine_to_display_the_sub_departments = () =>
             {
                 response_engine.received(x => x.handle(departments));
             };

             static Repository repository;
             static Request request;
             static ReponseEngine response_engine;
             static IEnumerable<Product> departments;
         }
     }
 }
