import React, { Fragment } from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import { Feed } from "./pages/Feed";
import { Profile } from "./pages/Profile";
import { Political } from "./pages/Political";

const Routes = () => {
  const AppStack = createStackNavigator();
  return (
    <NavigationContainer>
      <AppStack.Navigator screenOptions={{ headerShown: true }}>
        <AppStack.Screen name="Feed" component={Feed} />
        <AppStack.Screen name="Profile" component={Profile} />
        <AppStack.Screen name="Political" component={Political} />
      </AppStack.Navigator>
    </NavigationContainer>
  );
}
export default Routes;
//<AppStack.Screen name="Login" component={Login} />