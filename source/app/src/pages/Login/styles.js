import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

export default StyleSheet.create({
    container: {
        flex: 1,
        paddingHorizontal: 16,
        paddingTop: Constants.statusBarHeight + 20,
        alignItems: 'center',
        justifyContent: 'space-around',
    },
    
    image: {
      resizeMode: 'center',
    },

    detailsButtonLogin: {
      flexDirection: 'row',
      justifyContent: 'space-between',
      alignItems: 'center',
      paddingVertical: 8,
      paddingHorizontal: 30,
      borderRadius: 8,
      backgroundColor: "#1196ef",
  },

 detailsButtonText: {
     fontSize: 14,
     fontWeight: 'bold',
     color: '#fefefe',
     marginLeft: 15,
 },

});