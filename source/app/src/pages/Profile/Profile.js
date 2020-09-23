import React, { useState, useEffect } from "react";
import { Feather } from "@expo/vector-icons";
import { View, TouchableOpacity, Image, Text } from "react-native";
import loadPersonalProfile from "../../services/loadPersonalProfile"
import styles from "./styles";

const Profile = (id) => {
  const [profile, setPerfil] = useState({});

  useEffect(() => {
    loadPersonalProfile(setPerfil, 2);
  }, []);

  return (
    <View style={styles.container}>
      <View style={styles.profile}>
        <Text style={styles.name}>{profile.fullName}</Text>

        <View style={styles.socialInteraction}>
          <TouchableOpacity style={styles.following} onPress={() => {}}>
            <Feather name="users" size={21} color="#407294" />
            <Text style={styles.followingText}>Seguindo {profile.following} Políticos </Text>
          </TouchableOpacity>

          <TouchableOpacity style={styles.interactions} onPress={() => {}}>
            <Feather name="tag" size={21} color="#407294" />
            <Text style={styles.interactionsText}>{profile.answers}  Interações </Text>
          </TouchableOpacity>
        </View>
      </View>
    </View>
  );
};
export default Profile;
