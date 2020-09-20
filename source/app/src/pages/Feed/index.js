import React from 'react';
import { View, Image, Text, TouchableOpacity, Button } from 'react-native';

import logoImg from '../../assets/logo.png';

import styles from './styles';

export default function Feed() {
    return (
        <View style={styles.container}>
            <View style={styles.header}>
                <Image source={logoImg} style={styles.image} />
                <Text style={styles.headerText}>
                    Hey, fulano enjoy this experience!
                </Text>
            </View>

            <View style={styles.postList}>
                <View style={styles.post}>
                    <Text style={styles.politicalName}>Bolsonaro</Text>
                    <Text style={styles.politicalOffice}>Presidente</Text>
                    
                    <View style={styles.postDetail}>
                        <Text style={styles.title}> Medida Provisória</Text>
                        <Text style={styles.content}>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,</Text>
                    </View>

                    <View style={styles.postVoting}>
                        <Button
                            title="Sim"
                            color="#b1ecd5"
                            onPress={() => {}}
                        />
                        
                        <Button
                            title="Não"
                            color="#ff808c"
                            onPress={() => {}}
                        />

                    </View>
                </View>
            </View>

        </View>
    );
}