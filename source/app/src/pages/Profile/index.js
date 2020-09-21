import React from 'react';
import { Feather } from '@expo/vector-icons';
import { View, TouchableOpacity, Image, Text} from 'react-native';

import styles from './styles';

export default function Profile() {
    return (
        <View style={styles.container}> 
            <View style={styles.profile}>
                <Image
                    style={styles.avatar}
                    source={{
                    uri:
                        'https://ecommercedesucesso.com.br/wp-content/uploads/2017/11/MarkThor-RenderingsPressConference-THOR1467.jpg',
                    }}
                />
                <Text style={styles.name}>Flávio Augusto  </Text>
                
                <View style={styles.socialInteraction}>
                    <TouchableOpacity
                        style={styles.following}
                        onPress={() => {}}
                    >
                        <Feather name="users" size={21} color="#407294"/>
                        <Text style={styles.followingText}>Seguindo 19 Políticos </Text>
                    </TouchableOpacity>

                    <TouchableOpacity
                        style={styles.interactions}
                        onPress={() => {}}
                    >
                        <Feather name="tag" size={21} color="#407294"/>
                        <Text style={styles.interactionsText}>125 Interações </Text>
                    </TouchableOpacity>
                </View>
                <TouchableOpacity
                        style={styles.interactions}
                        onPress={() => {}}
                    >
                        <Feather name="edit" size={21} color="#407294"/>
                        <Text style={styles.interactionsText}>Editar Perfil </Text>
                    </TouchableOpacity>
            </View>
        </View>
    );
};