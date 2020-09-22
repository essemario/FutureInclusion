import React, { useState, useEffect } from 'react';
import { Feather } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';
import { View, FlatList, Image, Text, TouchableOpacity } from 'react-native';

import api from '../../services/api';

import logoImg from '../../assets/logo.png';

import styles from './styles';

const Feed = () => {

    const [posts, setPosts] = useState([]);

    const navigation = useNavigation();

    function navigateToProfile() {
        navigation.navigate('Profile');
    };

    function navigateToPolitical() {
        navigation.navigate('Political');
    };

    function navigateToLogin() {
        navigation.navigate('Login');
    };

    async function loadPosts() {
        const response = await api.get('Postagens');

        setPosts(response.data);
    }

    useEffect(() => {
        loadPosts();
    }, [])

    return (
        <View style={styles.container}>
            <View style={styles.header}>
                <Image source={logoImg} style={styles.image} />
                <View style={styles.headerIcons}> 
                    <TouchableOpacity
                        style={styles.profile}
                        onPress={navigateToProfile}
                    >
                        <Feather name="user" size={21} color="#00B0F0"/>
                        <Text style={styles.profileText}>Perfil</Text>
                    </TouchableOpacity>

                    <TouchableOpacity
                        style={styles.logout}
                        onPress={navigateToLogin}
                    >
                        <Feather name="log-out" size={21} color="#b64029"/>
                        <Text style={styles.profileText}>Logout</Text>
                    </TouchableOpacity>
                </View>
            </View>

            <FlatList 
                data={posts}
                style={styles.postList}
                keyExtractor={post => String(post.id)}
                renderItem={({ item: post}) => (
                    <View style={styles.post}>
                        <TouchableOpacity 
                            style={styles.personal}
                            onPress={navigateToPolitical}
                        >
                            <Image
                                style={styles.avatar}
                                source={{
                                uri:
                                    'https://www.cartacapital.com.br/wp-content/uploads/2020/04/Jair-Bolsonaro-Foto-EVARISTO-SA-_-AFP.jpg',
                                }}
                            />
                            <View style={styles.peronsalText}>
                                <Text style={styles.politicalName}>Jair Messias Bolsonaro </Text>
                            <Text style={styles.politicalOffice}>{post.mandateId}</Text>
                            </View>
                        </TouchableOpacity>
                        
                    
                        <View style={styles.postDetail}>
                            <Text style={styles.title}>{post.text}</Text>
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
export default Feed;