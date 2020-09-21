import React from 'react';
import { Feather } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';
import { View, Image, TouchableOpacity, Text } from 'react-native';

import logo2 from '../../assets/logo2.png';

import styles from './styles';

const Login = () => {
    const navigation = useNavigation();
    
    function navigateToFeed() {
        navigation.navigate('Feed');
    };

    return (
        <View style={styles.container}>
                <Image source={logo2} style={styles.image} />
                
                <View style={styles.actions}>
                    <TouchableOpacity
                        style={styles.detailsButtonLogin}
                        onPress={navigateToFeed}
                    >
                        <Feather name="facebook" size={24} color="#fff"/>
                        <Text style={styles.detailsButtonText}> Login com Facebook </Text>
                    </TouchableOpacity>
            </View>
        </View>
    );
}

export default Login;