import React from 'react';
import { Feather } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';
import { View, FlatList, TouchableOpacity, Image, Text } from 'react-native';

import styles from './styles';

const Political = () => {
    const navigation = useNavigation();

    function navigateToFeed() {
        navigation.navigate('Feed');
    };

    function navigateToProfile() {
        navigation.navigate('Profile');
    };

    return (
        <View style={styles.container}> 
            <View style={styles.politicalProfile}>
                <Image
                    style={styles.avatar}
                    source={{
                    uri:
                        'https://www.cartacapital.com.br/wp-content/uploads/2020/04/Jair-Bolsonaro-Foto-EVARISTO-SA-_-AFP.jpg',
                    }}
                />
                <View style={styles.personalText}>
                    <Text style={styles.politicalName}>Jair Messias Bolsonaro </Text>
                    <Text style={styles.politicalOffice}>Presidente </Text>
                    <TouchableOpacity
                        style={styles.follow}
                        onPress={() => {}}
                    >
                        <Text style={styles.followText}>Seguindo </Text>
                    </TouchableOpacity>
                </View>
                

                <View style={styles.socialInteraction}>
                    <TouchableOpacity
                        style={styles.followers}
                        onPress={() => {}}
                    >
                        <Feather name="users" size={21} color="#407294"/>
                        <Text style={styles.followersText}>20.504 Seguidores</Text>
                    </TouchableOpacity>

                    <TouchableOpacity
                        style={styles.answers}
                        onPress={() => {}}
                    >
                        <Feather name="tag" size={21} color="#407294"/>
                        <Text style={styles.answersText}>70.892 Respostas</Text>
                    </TouchableOpacity>
                </View>
            </View>
            
            <FlatList 
                data={[1, 2, 3, 4, 5, 6, 7]}
                style={styles.postList}
                keyExtractor={post => String(post)}
                renderItem={() => (
                    <View style={styles.post}>
  
                        <View style={styles.postDetail}>
                            <Text style={styles.title}> Medida Provisória</Text>
                            <Text style={styles.content}>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</Text>
                        </View>

                        <View style={styles.postVoting}>
                            <TouchableOpacity
                                style={styles.detailsButtonYes}
                                onPress={() => {}}
                            >
                                <Text style={styles.detailsButtonText}> Sim </Text>
                                <Feather name="check" size={16} color="#008080"/>
                            </TouchableOpacity>

                            <TouchableOpacity
                                style={styles.detailsButtonNo}
                                onPress={() => {}}
                            >
                                <Text style={styles.detailsButtonText}> Não </Text>
                                <Feather name="x" size={16} color="#b64029"/>
                            </TouchableOpacity>
                        </View>
                </View>

                )}
            />

        </View>
    );
}
export default Political;