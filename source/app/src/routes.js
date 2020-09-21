import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const AppStack = createStackNavigator();

import Login from './pages/Login';
import Feed from './pages/Feed';
import Profile from './pages/Profile';
import Political from './pages/Political';

export default function Routes() {
    return (
        <NavigationContainer>
            <AppStack.Navigator screenOptions={{ headerShown: false }}>
                <AppStack.Screen name="Feed" component={Feed} />
                <AppStack.Screen name="Login" component={Login} />
                <AppStack.Screen name="Profile" component={Profile} />
                <AppStack.Screen name="Political" component={Political} />
            </AppStack.Navigator>

        </NavigationContainer>
    )
}