import React, { useState, useEffect } from "react";
import { Feather } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import { View, FlatList, Image, Text, TouchableOpacity } from "react-native";
import { Header } from "../Header";
import loadFeed from "../../services/api";
import styles from "./styles";

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
        renderItem={({ item: post }) => (
          <View style={styles.post}>
            <TouchableOpacity
              style={styles.personal}
              onPress={() => navigate("Political", { name: "XYZ" })}
            >
              <Image
                style={styles.avatar}
                source={{
                  uri:
                    "https://www.cartacapital.com.br/wp-content/uploads/2020/04/Jair-Bolsonaro-Foto-EVARISTO-SA-_-AFP.jpg",
                }}
              />
              <View style={styles.peronsalText}>
                <Text style={styles.politicalName}>
                  Jair Messias Bolsonaro{" "}
                </Text>
                <Text style={styles.politicalOffice}>{post.mandateId}</Text>
              </View>
            </TouchableOpacity>

            <View style={styles.postDetail}>
              <Text style={styles.title}>{post.text}</Text>
              <Text style={styles.content}>
                Lorem Ipsum is simply dummy text of the printing and typesetting
                industry. Lorem Ipsum has been the industry's standard dummy
                text ever since the 1500s.
              </Text>
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
