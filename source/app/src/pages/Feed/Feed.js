import React, { useState, useEffect } from "react";
import { Feather } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import { View, FlatList, Image, Text, TouchableOpacity } from "react-native";
import { Header } from "../Header";
import loadFeed from "../../services/api";
import styles from "./styles";
import {TinyProfile} from "../../components/TinyProfile";

const Feed = () => {
  const { navigate } = useNavigation();
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    loadFeed(setPosts);
  }, []);

  return (
    <View style={styles.container}>
      <Header />
      <FlatList
        data={posts}
        style={styles.postList}
        keyExtractor={(post) => String(post.id)}
        renderItem={({ item: poll }) => (
          <View style={styles.post}>
            <TinyProfile politic={poll.politic}/>
            
            <View style={styles.postDetail}>
              <Text style={styles.title}>{poll.title}</Text>
              <Text style={styles.content}>{poll.description}</Text>
            </View>



            <View style={styles.postVoting}>
              <TouchableOpacity
                style={styles.detailsButtonYes}
                onPress={() => {}}
              >
                <Text style={styles.detailsButtonText}> Sim </Text>
                <Feather name="check" size={16} color="#008080" />
              </TouchableOpacity>

              <TouchableOpacity
                style={styles.detailsButtonNo}
                onPress={() => {}}
              >
                <Text style={styles.detailsButtonText}> Não </Text>
                <Feather name="x" size={16} color="#b64029" />
              </TouchableOpacity>
            </View>
          </View>
        )}
      />
    </View>
  );
};
export default Feed;
