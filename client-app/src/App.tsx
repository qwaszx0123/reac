import React, { Component } from 'react';
import { Header, Icon, List } from 'semantic-ui-react';
import './App.css';
import axios from 'axios';

class App extends Component {
  // 00:00:18.170 ~ 00:00:20.960  And to do this as I mentioned each we act.
  // 00:00:20.960 ~ 00:00:26.470  Class component can use component states and to do this.
  // 00:00:26.470 ~ 00:00:36.050  We can declare states objects inside the class and we can say states equals and open some curly brackets.
  state = {
    values: []
  };

  // 00:02:04.050 ~ 00:02:09.560  But just to keep things as straightforward and simple as possible what we're doing here is when our
  // 00:02:09.560 ~ 00:02:20.050  component first loads the state is going to be an empty array inside this values property and after



  // 00:04:10.250 ~ 00:04:17.080  But very briefly what we're looking at here is not hasty AML but it is actually javascript and it's
  // 00:04:17.080 ~ 00:04:24.790  javascript styled in such a way as it makes it look and feel like we're writing aged CML but it is actually
  // 00:04:24.790 ~ 00:04:30.310  javascript and it gives us a great deal of advantage here because we can write our components as though
  // 00:04:30.310 ~ 00:04:37.630  we're just making a static hasty AML page but we've got all of the functionality available hands to
  // 00:04:37.630 ~ 00:04:44.560  add whatever javascript functionality we want inside here and like I say we'll get deeper into what


  //change from function compont to class component  need render (){}


    // 00:00:36.210 ~ 00:00:41.940  And then for now we're just going to stick with our simple little values and our values is going to
  // 00:00:41.940 ~ 00:00:51.400  be an array that we store inside our states object and what we'll also do is use a component the Mount
  // 00:00:52.110 ~ 00:00:59.430  method reacts lifecycle method which is called immediately after a component is mounted.
  // 00:00:59.430 ~ 00:01:04.950  And when we set state here we trigger a rebrand of our component.
  // 00:01:05.280 ~ 00:01:12.120  And then our updated status is displayed on our page and we'll be able to see this in action.


  // 00:00:59.430 ~ 00:01:04.950  And when we set state here we trigger a rebrand of our component.

  //get method return a promise
  componentDidMount() {
    axios.get('http://localhost:5000/api/values').then(response => {
      console.log(response);
      this.setState({
        values: response.data
      });
    });
  }


  // 00:00:48.720 ~ 00:00:56.130  This is a good place to go and get some data from an API and what we do is we wait until the components
  // 00:00:56.130 ~ 00:01:02.940  mounted go and fetch some data and then we call this set state to update the state.
  // componentDidMount() {
  //   //  00:01:18.610 ~ 00:01:27.250  a we act component class method called this dot set state so that we can modify what's going on inside
  //   this.setState({
  //     values:[{
  //       Id : 1,
  //       Name : "Value 101"
  //   },
  //   {
  //       Id :2,
  //       Name : "Value 102"
  //   }]
  //   })
  // }


  //becasue of loop should add    key in li   to avoid warning
  render() {
    return (
      <div>
        <Header as='h2'>
          <Icon name='users' />
          <Header.Content>Reactivities</Header.Content>
        </Header>
        <List>
          {this.state.values.map((value: any) => (
            <List.Item key={value.id}>{value.name}</List.Item>
          ))}
        </List>
{/* use map to loop */}
        {/* <ul>
          {this.state.values.map((value : any)=>(

            <li key={value.Nam}>{value.Name}</li>
          ))}
        </ul> */}
      </div>
    );
  }
}

export default App;
