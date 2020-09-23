import React, { useState, useEffect, Fragment } from "react";
import { Feather } from "@expo/vector-icons";
import { View, FlatList, TouchableOpacity, Image, Text } from "react-native";
import loadPolitcProfile from "../../services/loadPolitcProfile"
import styles from "./styles";

const Political = ({ navigation, route }) => {
  const [profile, setPerfil] = useState({});

  useEffect(() => {
    loadPolitcProfile(setPerfil, route.params.name);
  }, []);
  return (
    <View style={styles.container}>
      <View style={styles.politicalProfile}>
        <View style={styles.personalText}>
          <Text style={styles.politicalName}>{profile.name}</Text>
          <Text style={styles.politicalOffice}>{profile.mandateName} </Text>
        </View>

        <View style={styles.socialInteraction}>
          <TouchableOpacity style={styles.followers} onPress={() => {}}>
            <Feather name="users" size={21} color="#407294" />
            <Text style={styles.followersText}>{profile.followers} Seguidores</Text>
          </TouchableOpacity>
        </View>
      </View>
    </View>
  );
};
export default Political;
