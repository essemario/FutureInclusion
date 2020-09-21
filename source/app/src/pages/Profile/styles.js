import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

export default StyleSheet.create({
    container: {
        flex: 1,
        paddingHorizontal: 16,
        paddingTop: Constants.statusBarHeight + 20,
    },
    
     profile: {
        alignItems: 'center',
        justifyContent: 'center',
     },

     avatar: {
        width: 120,
        height: 120,
        borderRadius: 60,
        marginRight: 12,
     },

     name: {
        alignItems: 'center',
        fontSize: 24,
        color: '#41414d',
        fontWeight: 'bold',
     },

     socialInteraction: {
         marginTop: 12,
         marginBottom: 12, 
         flexDirection: 'row',
         justifyContent: 'space-between',
     },

     following: {
        flexDirection: 'row',
        alignItems: 'center',
        paddingHorizontal: 16,
     },

     followingText: {
        marginLeft: 8,
     },

     interactions: {
         flexDirection: 'row',
        alignItems: 'center',
        paddingHorizontal: 16,
     },

     interactionsText: {
        marginLeft: 8,
     },
});