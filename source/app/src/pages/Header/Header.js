import React from "react";
import { Feather } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import { View, Image, TouchableOpacity, Text } from "react-native";

import styles from "./styles";

const Header = () => {
  const { navigate } = useNavigation();
  return (
    <View style={styles.header}>
      <Image source={require("../../assets/logo.png")} />
      <View style={styles.headerIcons}>
        <TouchableOpacity
          style={styles.profile}
          onPress={() => navigate("Profile")}
        >
          <Feather name="user" size={21} color="#00B0F0" />
          <Text>Perfil</Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.logout}
          //onPress={() => navigate("Login")}
        >
          <Feather name="log-out" size={21} color="#b64029" />
          <Text style={styles.profileText}>Logout</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
};
export default Header;
